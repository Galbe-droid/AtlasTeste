import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Http2Server } from 'http2';

@Injectable({
  providedIn: 'root'
})
export class TrabalhadoresService {

constructor(private http: HttpClient) { }

getAll(){
  return this.http.get("");
}

getByName(nome: string){
  return this.http.get("url/${nome}");
}

}
