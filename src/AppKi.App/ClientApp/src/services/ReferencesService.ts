import { AService } from './AService';
import { ResponseWithData } from './commons/models';

export interface ReferenceType {
  id: number | string;
  value: string;
}

export class ReferencesService extends AService {
  protected static BASE_URI = 'references';

  public static types(
    props: string
  ): Promise<ResponseWithData<ReferenceType[]>> {
    return this.get(`/enums/${props}`);
  }

}