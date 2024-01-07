import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InstitutionService {

  constructor(private http: HttpClient) { }

  createInstitution(institution: any): Observable<any> {
    return this.http.post('https://localhost:5001/api/createinstitution', institution);
  }
}
