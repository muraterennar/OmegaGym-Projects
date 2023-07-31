import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ClaimType } from 'src/app/guards/common/auth.guard';

@Component({
  selector: 'user-panel-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  constructor(private jwtHelper: JwtHelperService) {}
  
  ngOnInit(): void {
    this.userControl();
  }

  fullName?:string;
  gender?:string = 'erkek';

  userControl(){
   const token: string = localStorage.getItem('token');
   var decotedToken: any = this.jwtHelper.decodeToken(token);

   const firstName:string = decotedToken[ClaimType.firstName];
   const lastName:string = decotedToken[ClaimType.lastName];

    this.fullName = firstName + " " + lastName;
    this.gender = decotedToken[ClaimType.gender];
  }

}
