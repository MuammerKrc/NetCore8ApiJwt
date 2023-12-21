import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA , MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css'],
})

export class DeleteDialogComponent {
  constructor(public dialogRef:MatDialogRef<DeleteDialogComponent>,@Inject(MAT_DIALOG_DATA) public data:string){}

  onYesClick(){
    this.dialogRef.close(DeleteDialogEnum.yes);
  }
  onNoClick(){
    this.dialogRef.close(DeleteDialogEnum.no);
  }
}
export enum DeleteDialogEnum{
  yes,
  no
}
