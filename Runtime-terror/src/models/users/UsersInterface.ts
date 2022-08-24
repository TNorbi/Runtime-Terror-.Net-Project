
export interface UserInterface {
  code: number;
  message: string;
  userList: UserList[];
}
export interface UserList {
  Id: number;
  userName: string;
  password: string;
  firstName: string | null;
  lastName: string | null;
  gender: string | null;
  email: string;
}
