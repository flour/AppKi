import { ReferenceType } from '../services/ReferencesService';

export const referenceToOption = (input: ReferenceType) => {
  return { label: input.value, value: input.id };
};