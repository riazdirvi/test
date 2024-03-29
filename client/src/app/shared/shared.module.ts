import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule}  from 'ngx-bootstrap/pagination';
import { CarouselModule } from 'ngx-bootstrap/carousel'
import { PagingHeaderComponent } from './compenents/paging-header/paging-header.component';
import { PagerComponent } from './compenents/pager/pager.component';



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot()
  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    CarouselModule
  ]
})
export class SharedModule { }
