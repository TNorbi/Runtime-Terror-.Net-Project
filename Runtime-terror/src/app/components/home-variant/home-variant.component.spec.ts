import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeVariantComponent } from './home-variant.component';

describe('HomeVariantComponent', () => {
  let component: HomeVariantComponent;
  let fixture: ComponentFixture<HomeVariantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HomeVariantComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeVariantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
