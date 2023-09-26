import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Propietario } from '../models/propietario';

@Injectable({
    providedIn: 'root'
  })
export class PropietarioService{

    myAppUrl: string 
    myApiUrl: string

    constructor(private http: HttpClient) { 
        this.myAppUrl = environment.endpoint
        this.myApiUrl = '/api/Propietario/'
    }

    getPropietario(propId: number | undefined): Observable<any>{
        return this.http.get(this.myAppUrl + this.myApiUrl + propId)
    }

    getListPropietarios(): Observable<any>{
        return this.http.get(this.myAppUrl + this.myApiUrl)
    }

    savePropietario(propietario: Propietario): Observable<any>{
        return this.http.post(this.myAppUrl + this.myApiUrl, propietario)
    }

    editPropietario(propietarioId: number | undefined, propietario: Propietario): Observable<any>{
        return this.http.put(this.myAppUrl + this.myApiUrl + propietarioId, propietario)
    }

    deletePropietario(propietarioId: number | undefined): Observable<any>{
        return this.http.delete(this.myAppUrl + this.myApiUrl + propietarioId)
    }
}