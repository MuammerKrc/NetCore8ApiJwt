import { Inject, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@microsoft/signalr';
import { BASE_PATH } from 'src/generated_endpoints';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor(@Inject(BASE_PATH) private basePath:string) { }

  private _connection:HubConnection;

  get connection():HubConnection{
    return this._connection;
  }

  start(hubUrl:string){
    if(!this.connection||this._connection?.state==HubConnectionState.Disconnected){
      const builder: HubConnectionBuilder =new HubConnectionBuilder();

      this._connection=builder
      .withUrl(this.basePath+"/"+hubUrl)
      .withAutomaticReconnect()
      .build();

      this.connection.start().then(()=>{
        console.log("Connected")
      }).catch(err=>{
        setTimeout(() => {
          this.start(hubUrl);
        }, 2000);
      })
    }

    this._connection.onreconnected((connectionId)=>console.log(connectionId,"reconnected"));
    this._connection.onreconnecting((err)=> console.log("err reconnecting",err));
    this._connection.onclose((err)=>console.log("close connection", err));
  }

  invoke(procedureName:string,message:any,successCallback?:(value)=>void,errorCallback?:(error)=>void){
    this.connection.invoke(procedureName,message).then(successCallback).catch(errorCallback);
  }

  on(procedureName:string,callback:(...message)=>void){
    this.connection.on(procedureName,callback);
  }
}
