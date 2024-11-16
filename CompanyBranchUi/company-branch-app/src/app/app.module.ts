import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BranchListComponent } from './components/branch-list/branch-list.component';
import { BranchDetailComponent } from './components/branch-detail/branch-detail.component';
import { BranchCreateComponent } from './components/branch-create/branch-create.component';
import { BranchUpdateComponent } from './components/branch-update/branch-update.component';
import { HttpClientModule } from '@angular/common/http'; 
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';



@NgModule({
  declarations: [
    AppComponent,
    BranchListComponent,
    BranchDetailComponent,
    BranchCreateComponent,
    BranchUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule ,
    MatTableModule,
    FormsModule,
    MatFormFieldModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
