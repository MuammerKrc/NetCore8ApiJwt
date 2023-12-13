import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService, CreateUserDto, JWTokensDto } from 'src/generated_endpoints';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
constructor(private formBuilder:FormBuilder,private accountService:AccountService){}

registerForm :FormGroup;
createUserDto:CreateUserDto;
  ngOnInit(): void {
    this.registerForm=this.formBuilder.group({
      Name:["",[Validators.required]],
      Surname:["",[Validators.required]],
      Email:["",[Validators.required,Validators.email]],
      Password:["",[Validators.required,Validators.minLength(6)]],
      PasswordCheck:["",[Validators.required,Validators.minLength(6)]],
    })
  }

  onSubmit(){
    this.createUserDto = this.registerForm.value as CreateUserDto;
    if(this.registerForm.valid){
      console.log(this.createUserDto);
      this.accountService.accountCreateUserPost(this.createUserDto).subscribe((d)=>{
      });
    }else{
      alert('deneme')
    }
  }

}
