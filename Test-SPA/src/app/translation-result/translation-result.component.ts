import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslationService } from '../_services/translation.service';

@Component({
  selector: 'app-translation-result',
  templateUrl: './translation-result.component.html',
  styleUrls: ['./translation-result.component.css'],
})
export class TranslationResultComponent implements OnInit {
  translation = '';

  constructor(
    private router: Router,
    private translationService: TranslationService
  ) {}

  ngOnInit(): void {
    this.translationService.data.subscribe((data) => {
      this.translation = data;
    });
  }

  back() {
    this.router.navigate(['/home']);
  }
}
