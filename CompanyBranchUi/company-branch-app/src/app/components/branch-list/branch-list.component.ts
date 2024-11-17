import { Component } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Branch } from 'src/app/models/branch';
import { PagedResult } from 'src/app/models/PagedResult';
import { BranchService } from 'src/app/services/branch.service';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.css']
})
export class BranchListComponent {
  branches: Branch[] = [];
  totalCount: number = 0;
  pageNumber: number = 1;
  pageSize: number = 10;
  displayedColumns: string[] = ['name', 'location', 'company', 'actions'];
  constructor(private branchService: BranchService) {}

  ngOnInit(): void {
    this.loadBranches();
  }

  loadBranches(): void {
    this.branchService.getAllBranches(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<Branch>) => {
        // result is now of type PagedResult<Branch>, so we can directly map the data
        this.branches = result.items;
         // result.items is an array of Branches
        console.log('Mapped branches:', this.branches);
  
        this.totalCount = result.totalCount; // Set the total count for pagination or other logic
      },
      error: (err) => console.error('Error loading branches:', err),
    });
  }
  
  onPageChange(event: PageEvent): void {
    this.pageNumber = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadBranches();
  }
  
  

  deleteBranch(id: number): void {
    if (id) {
      this.branchService.deleteBranch(id).subscribe({
        next: (response) => console.log('Branch deleted', response),
        error: (err) => console.error('Error deleting branch:', err),
      });
    } else {
      console.error('Invalid branch ID');
    }
  }
}
