import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'age',
})
export class AgePipe implements PipeTransform {
  transform(value: string): number {
    const toady = new Date();
    const dob = new Date(value);

    let age = toady.getFullYear() - dob.getFullYear();
    const monthDiff = toady.getMonth() - dob.getMonth();

    if (monthDiff < 0 || (monthDiff === 0 && toady.getDate() < dob.getDate())) {
      age--;
    }

    return age;
  }
}
