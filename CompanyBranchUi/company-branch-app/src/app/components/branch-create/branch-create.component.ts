import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Branch, CreateBranch } from 'src/app/models/branch';
import { BranchService } from 'src/app/services/branch.service';
import { CompanyService } from 'src/app/services/CompanyService ';

@Component({
  selector: 'app-branch-create',
  templateUrl: './branch-create.component.html',
  styleUrls: ['./branch-create.component.css']
})
export class BranchCreateComponent {
  branch: CreateBranch = { id: 0, name: '',location:'',companyId:0, isDeleted: false };
  companies: any[] = [];
  pageNumber = 1;
  pageSize = 10;
  constructor(private branchService: BranchService,private companyService: CompanyService, private router: Router) {}
  ngOnInit(): void {
    this.loadCompanies();
  }
  createBranch(): void {
    this.branchService.createBranch(this.branch).subscribe({
      next: () => this.router.navigate(['/']),
      error: (err) => console.error('Error creating branch:', err),
    });
  } 
  loadCompanies(): void {
    this.companyService.getCompanies(this.pageNumber, this.pageSize).subscribe({
      next: (response) => {
        this.companies = response.items;
      },
      error: (err) => console.error('Error loading companies:', err),
    });
  }
}
