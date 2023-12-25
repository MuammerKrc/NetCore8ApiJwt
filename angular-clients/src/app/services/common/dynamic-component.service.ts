import { Component, ComponentFactoryResolver, Injectable, ViewContainerRef } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DynamicComponentService {

  constructor(private componentFactoryResolver:ComponentFactoryResolver) {
  }


  async loadComponent(component:ComponentType,viewContainerRef:ViewContainerRef){
    let _component :any=null;

    switch (component) {
      case ComponentType.BasketComponents:
        _component=await (await import("../../ui/baskets/baskets.component")).BasketsComponent
        break;
    }

    viewContainerRef.clear();
    return viewContainerRef.createComponent(_component);
  }
}

export enum ComponentType{
  BasketComponents
}
