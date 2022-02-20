import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Constants } from '../util/constants';

@Pipe({
  name: 'DateTimeFormat' // [Aula.84] → Este nome não pode ser o mesmo que o da Classe abaixo.
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  // [Aula.84] → Criando formato de apresentação de data na tela.
  override transform(value: any, args?: any): any {
    return super.transform(value, Constants.DATE_TIME_FMT);
  }

}
