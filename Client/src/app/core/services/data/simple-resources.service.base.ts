import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { apiRoot } from "../../constants";

@Injectable()
export abstract class SimpleResourceServiceBase<T> {
  constructor(protected http: HttpClient)
  {}

  abstract getResourceName(): string;

  getRoot(): string {
    return `${apiRoot}${this.getResourceName()}/`;
  }

  getMany(count: number, offset: number): Observable<T[]> {
    let url = `${this.getRoot()}`;
    let params = new HttpParams()
      .set("count", count)
      .set("offset", offset);
    return this.http.get<T[]>(url, {params});
  }

  get(id: number) : Observable<T> {
    let url = `${this.getRoot()}${id}`
    return this.http.get<T>(url);
  }
}
