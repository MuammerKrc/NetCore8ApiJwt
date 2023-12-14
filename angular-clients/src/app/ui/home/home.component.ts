import { Component } from '@angular/core';
import { AuthorizeService } from 'src/generated_endpoints';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private service:AuthorizeService){
    service.authorizeAdminRoleCheckPost().subscribe(x=>{
      x
    });
  }

}
