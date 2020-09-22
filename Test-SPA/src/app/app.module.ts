import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { TranslatorComponent } from './translator/translator.component';
import { TranslationResultComponent } from './translation-result/translation-result.component';
import { AppRoutingModule } from './app-routing-module';
import { TranslationService } from './_services/translation.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FormatTimePipe } from './format-time.pipe';

@NgModule({
  declarations: [AppComponent, TranslatorComponent, TranslationResultComponent, FormatTimePipe],
  imports: [
    MatCardModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatInputModule,
  ],
  providers: [TranslationService],
  bootstrap: [AppComponent],
})
export class AppModule {}
