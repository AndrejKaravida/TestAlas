import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TranslationResultComponent } from './translation-result/translation-result.component';
import { TranslatorComponent } from './translator/translator.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'home',
    component: TranslatorComponent,
  },
  {
    path: 'translator-result',
    component: TranslationResultComponent,
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' }),
  ],
  exports: [RouterModule],
  providers: [],
})
export class AppRoutingModule {}
