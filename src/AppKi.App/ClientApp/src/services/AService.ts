export abstract class AService {
  protected static getUrl(url: string): string {
    return `/api/v1/${url}`;
  }

  protected static async http(method: string, url: string, data?: any, options?: any): Promise<any> {
    const headers = {
      Accept: 'application/json',
      'Content-Type': 'application/json',
      // Authorization: `Bearer ${token}`,
      ...options
    };

    const originalResponse = await fetch(this.getUrl(url), {
      method,
      body: headers['Content-Type'] ? JSON.stringify(data) : data,
      headers
    });

    return new Promise(async (resolve, reject) => {
      if (originalResponse.headers.get('content-type') === 'application/pdf') {
        const res = originalResponse.blob();
        return resolve(res);
      }
      const successResult = await originalResponse.json();
      if (successResult.success === false) {
        return reject(successResult.message);
      }
      return resolve(successResult);
    });
  }

  protected static get(url: string, data?: any, options?: any): any {
    return this.http('GET', url, data, options);
  }

  protected static post(url: string, data?: any, options?: any): any {
    return this.http('POST', url, data, options);
  }

  protected static put(url: string, data?: any, options?: any): any {
    return this.http('PUT', url, data, options);
  }

  protected static delete(url: string, data?: any, options?: any): any {
    return this.http('DELETE', url, data, options);
  }
}