import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../admin.service';
import { ProjectViewModel } from '../Model/project.model';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css'],
})
export class ProjectComponent implements OnInit {
  projectList!: ProjectViewModel[];
  isDeletable!: boolean;
  deleteMessage!: string;

  constructor(private adminService: AdminService, private router: Router) { }

  ngOnInit(): void {
    this.getAllProjects();
  }
  getAllProjects() {
    this.adminService.getAllProject().subscribe((data) => {
      this.projectList = data;
    });
  }
  addProject() {
    this.router.navigateByUrl('admin/addProject');
  }

  editProject(id: number) {
    this.router.navigate(['admin/EditProject', id])
  }
  deleteProject(project: ProjectViewModel) {
    let employeeCount: number;

    this.adminService.getAllEmployees().subscribe(data => {
      employeeCount = data.filter(e => e.projectId == project.projectId).length;
      this.isDeletable = employeeCount == 0;
      
      if (this.isDeletable) {
        this.adminService.deleteProjectById(project.projectId).subscribe(data => {
          console.log("Delete status: " + data);
          this.getAllProjects();
          this.deleteMessage = "Project Deleted 👍";
        });
      }
      this.deleteMessage = `Can not be Deleted 👾. ${employeeCount} Employees' working on it. `;
    });
  }
}
