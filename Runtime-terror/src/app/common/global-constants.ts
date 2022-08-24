import { Injectable } from '@angular/core';

@Injectable()
export class GlobalConstants {
  public userID: number | undefined;
  public username: string | undefined;
  public loggedIn = false;
}
