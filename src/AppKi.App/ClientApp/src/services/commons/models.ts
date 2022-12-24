export interface ErrorMessage {
  key: string;
  message: string;
}

export interface ResponseWithData<T> {
  data: T;
  success: boolean;
  errors?: ErrorMessage[];
  total?: number;
  count?: number;
  page?: number;
}

export interface ResponseWithoutData {
  message?: string;
  success: boolean;
  errors?: ErrorMessage[];
}
