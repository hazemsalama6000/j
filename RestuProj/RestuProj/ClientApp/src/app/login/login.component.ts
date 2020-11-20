import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSnackBarVerticalPosition, MatSnackBarHorizontalPosition, MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: any = {};
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';


  constructor(private ob: HttpClient ,private router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  checkUser() {

    this.ob.get("User?Name=" + this.user.username + "&Pass=" + this.user.password).subscribe((data: any) => {
      if (data.action == 'y') {

        this._snackBar.open('Cannonball!!', 'End now', {
          duration: 500,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });          //this.toaster.success("Message","Login Success");

        this.router.navigate(['resturentPage']);
      }
      else {
        this._snackBar.open('User not Exist!!', 'End now', {
          duration: 500,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });          //this.toaster.success("Message","Login Success");


      }
    });

  }

}
