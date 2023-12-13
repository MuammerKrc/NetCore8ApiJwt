import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService, UserLoginDto } from 'src/generated_endpoints';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements OnInit {
  constructor(private formBuilder:FormBuilder,private accountService:AccountService){
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
        console.log(x);
      });
    }
  }
}
