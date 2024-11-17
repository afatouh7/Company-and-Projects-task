export class PagedResult<T> {
  items: T[] = [];
  totalCount: number = 0;
  totalPages: number = 0;
  currentPage: number = 0;
  pageSize: number = 0;
}
