import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Mascota } from '../models/mascota';

@Injectable({
    providedIn: 'root'
  })
export class MascotaService{

    myAppUrl: string 
    myApiUrl: string

    constructor(private http: HttpClient) { 
        this.myAppUrl = environment.endpoint
        this.myApiUrl = '/api/Mascota/'
    }

    getMascota(mascotaId: number | undefined): Observable<any>{
        return this.http.get(this.myAppUrl + this.myApiUrl + mascotaId)
    }

    getListMascotas(): Observable<any>{
        return this.http.get(this.myAppUrl + this.myApiUrl)
    }

    saveMascota(mascota: Mascota): Observable<any>{
        console.log(mascota)
        return this.http.post(this.myAppUrl + this.myApiUrl, mascota)
    }

    editMascota(mascota: Mascota, mascotaId: number | undefined): Observable<any>{
        return this.http.put(this.myAppUrl + this.myApiUrl + mascotaId, mascota)
    }

    deleteMascota(mascotaId: number | undefined): Observable<any>{
        return this.http.delete(this.myAppUrl + this.myApiUrl+mascotaId)
    }
}