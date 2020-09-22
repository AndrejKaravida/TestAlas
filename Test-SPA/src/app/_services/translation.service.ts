import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { Translation } from '../_models/translation';
import { SearchRequest } from '../_models/searchRequest';

@Injectable({
  providedIn: 'root',
})
export class TranslationService {
  baseUrl = `${environment.apiUrl}`;
  private dataSource = new BehaviorSubject<string>('');
  private lastTranslationsSource = new BehaviorSubject<string>('');
  private lastTranslationsonFirstLanguageSource = new BehaviorSubject<string>(
    ''
  );

  data = this.dataSource.asObservable();
  lastTranslations = this.lastTranslationsSource.asObservable();
  lastTranslationsonFirstLanguage = this.lastTranslationsonFirstLanguageSource.asObservable();

  constructor(private http: HttpClient) {}

  updateDataSelection(data: string) {
    this.dataSource.next(data);
  }

  updateLastTranslations(data: string) {
    this.lastTranslationsSource.next(data);
  }

  updateLastTranslationsonFirstLanguage(data: string) {
    this.lastTranslationsonFirstLanguageSource.next(data);
  }

  getTranslation(searchRequest: SearchRequest): Observable<Translation> {
    return this.http.post<Translation>(this.baseUrl, searchRequest);
  }
}
