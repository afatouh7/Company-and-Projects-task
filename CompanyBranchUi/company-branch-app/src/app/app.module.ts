import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
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
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select'; 
import { MatInputModule } from '@angular/material/input';
import { CompanyCreateComponent } from './company-create/company-create.component';





@NgModule({
  declarations: [
    AppComponent,
    BranchListComponent,
    BranchDetailComponent,
    BranchCreateComponent,
    BranchUpdateComponent,
    CompanyCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule ,
    MatTableModule,
    FormsModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSelectModule ,
    MatInputModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
