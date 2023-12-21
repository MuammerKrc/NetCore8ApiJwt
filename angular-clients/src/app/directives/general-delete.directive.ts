import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appGeneralDelete]'
})
export class GeneralDeleteDirective {
  @Input() id:string;
  @Output() deleteEvent:EventEmitter<any>=new EventEmitter<boolean>();

  constructor(private renderer:Renderer2,private elementRef:ElementRef) {
    const img:HTMLImageElement =renderer.createElement("img");
    img.setAttribute("src","/assets/delete.png");
    img.setAttribute("style","cursor:pointer");
    img.width=25;
    img.height=25;
    renderer.appendChild(elementRef.nativeElement,img);
  }



  @HostListener("click")
  onClickedHtmlElement(){
    this.deleteEvent.emit(true);
  }


}
