import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BranchListComponent } from './components/branch-list/branch-list.component';
import { BranchDetailComponent } from './components/branch-detail/branch-detail.component';
import { BranchCreateComponent } from './components/branch-create/branch-create.component';
import { BranchUpdateComponent } from './components/branch-update/branch-update.component';
import { CompanyCreateComponent } from './company-create/company-create.component';

const routes: Routes = [
  { path: '', component: BranchListComponent },
  { path: 'branch/:id', component: BranchDetailComponent },
  { path: 'create', component: BranchCreateComponent },
  { path: 'update/:id', component: BranchUpdateComponent },
  { path: 'create-company', component: CompanyCreateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
