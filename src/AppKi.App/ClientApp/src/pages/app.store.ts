import {createEffect, createEvent, createStore, EffectByHandler, sample, Store} from "effector";
import {persist} from "effector-storage/local";
import {ReferencesService, ReferenceType} from "@services/ReferencesService";
import {ResponseWithData} from "@services/commons/models";

enum refType {
  exchangeProviders = 'exchangeProvider',
  timeRanges = 'timeRange',
  tradeStrategyTypes = 'tradeStrategyType',
}

type EnumReferenceStore = Record<refType, string | undefined>;
type RefEffect = EffectByHandler<() => Promise<ResponseWithData<ReferenceType[]>>, Error>;

const enums = Object.values(refType);
const resetRequested = createEvent();

export const getEnumRefsRequested = createEvent();
const effects = enums.reduce((res: Record<string, RefEffect>, e: string) => {
  res[e] = createEffect(() => ReferencesService.getEnumRefs(e));
  return res;
}, {});

export const $references = Object.getOwnPropertyNames(effects).reduce(
  (store: Store<EnumReferenceStore>, effect: string) => {
    return store.on(effects[effect].doneData, (prev, state) => ({...prev, [effect]: state}))
  }, createStore<EnumReferenceStore>({} as EnumReferenceStore))
  .reset(resetRequested);

sample({
  clock: getEnumRefsRequested,
  target: Object.getOwnPropertyNames(effects).map(e => effects[e]),
});

const adapter = (timeout: any) => (key: string, update: any) => {
  addEventListener("storage", (event) => {
    if (event.key === key) {
      update(event.newValue);
    }
  });
  return {
    get: () => {
      const item = localStorage.getItem(key);
      if (item === null) return {}; // no value in localStorage
      const {time, value} = JSON.parse(item);
      if (time + timeout * 1000 < Date.now()) return; // value has expired
      return value;
    },

    set: (value: any) => {
      localStorage.setItem(key, JSON.stringify({time: Date.now(), value}));
    },
  };
};

// @ts-ignore
persist({
  store: $references,
  key: "appki-ref",
  adapter: adapter(3600),
});