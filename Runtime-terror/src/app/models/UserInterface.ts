export interface UserInterface {
  code: number;
  message: string;
  user: UserData | null;
}

export interface UserData {
  id: number;
  userName: string;
  password: string;
  firstName: string | null;
  lastName: string | null;
  gender: string | null;
  email: string;
  userRating: string | null;
}
