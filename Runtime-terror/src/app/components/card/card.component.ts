import { Component, Input, OnInit } from '@angular/core';
import { TitleType } from 'src/app/enums/title-type';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})
export class CardComponent implements OnInit {
  @Input() showTitle: boolean = true;
  @Input() titleType: TitleType = TitleType.YELLOW;
  @Input() fullHeight: boolean = true;
  public title: string = 'Placeholder';

  constructor() {}

  ngOnInit(): void {}
}
