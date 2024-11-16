import { Component } from '@angular/core';
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

  constructor(private branchService: BranchService) {}

  ngOnInit(): void {
    this.loadBranches();
  }

  loadBranches(): void {
    this.branchService.getAllBranches(this.pageNumber, this.pageSize).subscribe({
      next: (result: PagedResult<Branch>) => {
        this.branches = result.items;
        this.totalCount = result.totalCount;
      },
      error: (err) => console.error(err),
    });
  }

  deleteBranch(id: number): void {
    if (confirm('Are you sure you want to delete this branch?')) {
      this.branchService.deleteBranch(id).subscribe(() => this.loadBranches());
    }
  }
}
