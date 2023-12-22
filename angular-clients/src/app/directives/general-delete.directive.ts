import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { DialogsService } from '../services/common/dialogs.service';
import { DeleteDialogComponent } from '../dialogs/delete-dialog/delete-dialog.component';
import { DeleteDirectiveEventResponse } from '../models/delete-directive-event-response';

@Directive({
  selector: '[appGeneralDelete]'
})
export class GeneralDeleteDirective {
  @Input() id:string;
  @Output() deleteEvent:EventEmitter<DeleteDirectiveEventResponse>=new EventEmitter<DeleteDirectiveEventResponse>();

  constructor(private renderer:Renderer2,private elementRef:ElementRef,private dilaogService:DialogsService) {
    const img:HTMLImageElement =renderer.createElement("img");
    img.setAttribute("src","/assets/delete.png");
    img.setAttribute("style","cursor:pointer");
    img.width=25;
    img.height=25;
    renderer.appendChild(elementRef.nativeElement,img);
  }



  @HostListener("click")
  onClickedHtmlElement(){
    this.dilaogService.openDialog({
      componentType:DeleteDialogComponent,
      data:"Silmek istediğinize emin misiniz?",
      options:{
      },
      apllyClosedCallback:()=>{
        this.deleteEvent.emit({
          eventResponse:true,
          id:this.id
        });
      },
      rejectClosedCallback:()=>{
        this.deleteEvent.emit({
          eventResponse:false,
          id:this.id
        });
      }
    });
  }


}
