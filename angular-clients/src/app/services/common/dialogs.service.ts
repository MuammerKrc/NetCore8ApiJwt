import { Injectable } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { ComponentType } from 'ngx-toastr';
import { DeleteDialogEnum } from 'src/app/dialogs/delete-dialog/delete-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class DialogsService {

  constructor(public dialog:MatDialog) {
  }

  openDialog(dialogPrams:Partial<DialogParameters>){
    var dialogRef=this.dialog.open(dialogPrams.componentType,{
      width:dialogPrams.options.width,
      height:dialogPrams.options.height,
      position:dialogPrams.options.position,
      data:dialogPrams.data
    });

    dialogRef.afterClosed().subscribe(x=>{
      if(x == DeleteDialogEnum.yes){
        dialogPrams?.apllyClosedCallback();
      }else{
        dialogPrams?.rejectClosedCallback();
      }
    })
  }
}

export class DialogParameters {
  componentType: ComponentType<any>;
  data: any;
  rejectClosedCallback?: () => void;
  apllyClosedCallback?: () => void;
  options?: Partial<DialogOptions> = new DialogOptions();
}
export class DialogOptions {
  width?: string = "350px";
  height?: string;
  position?: DialogPosition;
}
