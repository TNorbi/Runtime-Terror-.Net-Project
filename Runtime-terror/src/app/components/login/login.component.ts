import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserInterface } from 'src/app/models/UserInterface';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/services/user.service';
import { GlobalConstants } from 'src/app/common/global-constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  //, public dialog: MatDialog
  constructor(
    private userService: UserService,
    private globalConstants: GlobalConstants
  ) {}
  title = 'LOGIN';
  @Output() onClose = new EventEmitter();
  @Output() loginSuccessful = new EventEmitter<string>();
  @Output() registerSuccessful = new EventEmitter();
  @Output() resetPasswordSuccessful = new EventEmitter();
  login: boolean = true;
  register: boolean = false;
  forgotPassword: boolean = false;

  iconSource: string = '../assets/icons/close.png';
  _loginUserData!: UserInterface;
  _registerUserData!: UserInterface;
  _resetPasswordData!: UserInterface;

  set loginUserData(value: UserInterface) {
    this._loginUserData = value;
    if (value.code === 200) {
      this.globalConstants.username = value.user?.userName;
      this.globalConstants.userID = value.user?.id;
      this.globalConstants.loggedIn = true;
      this.loginSuccessful.emit(value.user?.userName);
      console.log('login successful');
    }
  }
  get loginUserData(): UserInterface {
    return this._loginUserData;
  }

  set registerUserData(value: UserInterface) {
    this._registerUserData = value;
    if (value.code === 200) {
      this.registerSuccessful.emit();
      console.log('register successful');
    }
  }
  get registerUserData(): UserInterface {
    return this._registerUserData;
  }

  set resetPasswordData(value: UserInterface) {
    this._resetPasswordData = value;
    if (value.code === 200) {
      this.resetPasswordSuccessful.emit();
      console.log('reset password successful');
    }
  }
  get resetPasswordData(): UserInterface {
    return this._resetPasswordData;
  }

  public loginForm = new FormGroup({
    credentials: new FormGroup({
      username: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(50),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(50),
      ]),
    }),
  });

  public registerForm = new FormGroup({
    credentials: new FormGroup({
      username: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(50),
      ]),
      email: new FormControl('', [
        Validators.required,
        Validators.email,
        Validators.minLength(1),
        Validators.maxLength(50),
      ]),
      firstName: new FormControl('', [
        Validators.minLength(1),
        Validators.maxLength(50),
      ]),
      lastName: new FormControl('', [
        Validators.minLength(1),
        Validators.maxLength(50),
      ]),
    }),
  });

  public forgotPasswordForm = new FormGroup({
    credentials: new FormGroup({
      username: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(50),
      ]),
      email: new FormControl('', [
        Validators.required,
        Validators.email,
        Validators.minLength(1),
        Validators.maxLength(50),
      ]),
    }),
  });

  ngOnInit(): void {
    // document.body.style.overflow = 'none';
  }

  closeLogin() {
    console.log('exit');
    // let dialogRef = dialog.open(LoginComponent, {
    //   height: '400px',
    //   width: '600px',
    // });
    this.onClose.emit(false);
  }

  // openDialog() {
  //   const dialogRef = this.dialog.open(LoginComponent);

  //   dialogRef.afterClosed().subscribe((result) => {
  //     console.log(`Dialog result: ${result}`);
  //   });
  // }

  handleSubmit(): void {
    const username = this.loginForm.value.credentials.username;
    const password = this.loginForm.value.credentials.password;
    //console.log('username = ' + username, '\n password = ' + password);

    this.userService.loginUser(username, password).subscribe((data) => {
      this.loginUserData = data;
    });

    //console.log(this.loginUserData);
    setTimeout(() => {
      // <<<---using ()=> syntax
      if (this.loginUserData.code === 200) {
        this.onClose.emit();
      }
    }, 500);
  }

  toggleRegisterPage() {
    if (this.login === true) {
      this.login = false;
      this.register = true;
      this.forgotPassword = false;
      this.title = 'REGISTER';
    }
  }

  toggleForgotPasswordPage() {
    if (this.login === true) {
      this.login = false;
      this.register = false;
      this.forgotPassword = true;
      this.title = 'PASSWORD RESET';
    }
  }

  resetPasswordSubmit() {
    const username = this.forgotPasswordForm.value.credentials.username;
    const password = this.forgotPasswordForm.value.credentials.password;
    const email = this.forgotPasswordForm.value.credentials.email;

    this.userService
      .resetPassword(username, password, email)
      .subscribe((data) => {
        this.resetPasswordData = data;
      });
    setTimeout(() => {
      // <<<---using ()=> syntax
      console.log(this.resetPasswordData);
      if (this.resetPasswordData.code === 200) {
        this.onClose.emit();
      }
    }, 500);
  }

  registerUser() {
    const username = this.registerForm.value.credentials.username;
    const password = this.registerForm.value.credentials.password;
    const email = this.registerForm.value.credentials.email;
    const firstName = this.registerForm.value.credentials.firstName;
    const lastName = this.registerForm.value.credentials.lastName;

    this.userService
      .registerUser(username, password, email, firstName, lastName)
      .subscribe((data) => {
        this.registerUserData = data;
      });

    //console.log(this.loginUserData);
    setTimeout(() => {
      // <<<---using ()=> syntax
      console.log(this.registerUserData);
      if (this.registerUserData.code === 200) {
        this.onClose.emit();
      }
    }, 500);
  }
}
