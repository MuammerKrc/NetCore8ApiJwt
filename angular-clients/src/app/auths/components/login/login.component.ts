import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TokenStorageService } from 'src/app/services/authenticationServices/token-storage.service';
import { AccountService, UserLoginDto } from 'src/generated_endpoints';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements OnInit {
  constructor(
    private formBuilder:FormBuilder,
    private accountService:AccountService,private tokenService:TokenStorageService,private activeRouter:ActivatedRoute,private router:Router){


  }
  loginForm:FormGroup;

  ngOnInit(): void {
    this.loginForm=this.formBuilder.group({
      Email:["",Validators.required],
      Password:["",[Validators.required,Validators.minLength(6)]]
    })
  }


  onSubmit(){
    if(this.loginForm.valid){

      var userLoginDto=this.loginForm.value as UserLoginDto;
      this.accountService.accountLoginPost(userLoginDto).subscribe(x=>{
        this.tokenService.setToken(x);
        this.activeRouter.queryParams.subscribe(x=>{
          console.log(x);
          var returnUrl=x["returnUrl"];
          if(returnUrl!=null&&returnUrl!=""){
            this.router.navigateByUrl(returnUrl);
          }else{
            this.router.navigateByUrl("/");
          }
        })
      });
    }
  }
}
