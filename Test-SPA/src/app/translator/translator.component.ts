// tslint:disable: typedef
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, timer } from 'rxjs';
import { SearchRequest } from '../_models/searchRequest';
import { TranslationService } from '../_services/translation.service';

@Component({
  selector: 'app-translator',
  templateUrl: './translator.component.html',
  styleUrls: ['./translator.component.scss'],
})
export class TranslatorComponent implements OnInit {
  text = '';
  translatedText = '';
  lastTranslatedText = '';
  lastRequestOnFirstLanguage = '';
  stop = false;

  translatingText = '';

  countDown: Subscription;
  counter = 3;
  tick = 1000;

  constructor(
    private router: Router,
    private translationService: TranslationService
  ) {}

  ngOnInit() {
    this.countDown = timer(0, this.tick).subscribe(() => {
      if (this.counter > 0) {
        --this.counter;
      }

      if (
        this.counter === 0 &&
        this.text.length > 0 &&
        this.text !== this.lastRequestOnFirstLanguage &&
        !this.stop
      ) {
        this.translatingText = 'Translating...';
        this.stop = true;
        this.callTranslationService();
      }
    });

    this.translationService.lastTranslations.subscribe((response) => {
      this.lastTranslatedText = response;
    });

    this.translationService.lastTranslationsonFirstLanguage.subscribe(
      (response) => {
        this.text = response;
        this.lastRequestOnFirstLanguage = response;
      }
    );
  }

  onSearchChange(searchValue: string): void {
    this.counter = 3;
    this.translatingText = '';
  }

  translate() {
    if (this.text.length === 0) {
      alert('Please enter some data!');
      return;
    }

    if (this.text === this.lastRequestOnFirstLanguage) {
      this.router.navigate(['/translator-result']);
    } else {
      this.buttonPressed();
    }
  }

  callTranslationService() {
    const searchRequest: SearchRequest = {
      textRequest: this.text,
    };

    this.translationService.getTranslation(searchRequest).subscribe(
      (response) => {
        this.translatingText = '';
        this.lastRequestOnFirstLanguage = this.text;
        this.translatedText = response.englishText;
        this.lastTranslatedText = this.translatedText;
        this.stop = false;
        this.translationService.updateDataSelection(response.englishText);
        this.translationService.updateLastTranslations(response.englishText);
        this.translationService.updateLastTranslationsonFirstLanguage(
          this.text
        );
      },
      (error) => {
        alert('Server je preopterecen molim vas pokusajte kasnije');
      }
    );
  }

  buttonPressed() {
    const searchRequest: SearchRequest = {
      textRequest: this.text,
    };

    this.translationService.getTranslation(searchRequest).subscribe(
      (response) => {
        this.lastTranslatedText = this.translatedText;
        this.translatedText = response.englishText;
        this.translationService.updateDataSelection(response.englishText);
        this.translationService.updateLastTranslations(response.englishText);
        this.translationService.updateLastTranslationsonFirstLanguage(
          this.text
        );
        this.router.navigate(['/translator-result']);
      },
      (error) => {
        alert('We encountered an error... Please try again! ');
      }
    );
  }
}
