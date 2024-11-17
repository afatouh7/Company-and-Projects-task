export class  Branch {
  id: number | undefined;
  name: string | undefined;
  location: string | undefined;
  isDeleted: boolean | undefined;
  companyId: number | undefined;
  company: string | undefined;
  } 
  export class CreateBranch {
    id: number | undefined;
    name: string | undefined;
    location: string | undefined;
    isDeleted: boolean | undefined;
    companyId: number | undefined;
    } 
 
 
 export class  Company {
    id: number | undefined;
  name: string | undefined;
  address: string | undefined;
  isDeleted: boolean | undefined;
  branch?: Branch | null | undefined;
  }