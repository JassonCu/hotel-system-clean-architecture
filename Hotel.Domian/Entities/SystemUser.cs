using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class SystemUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<Department> DepartmentCreatedByNavigations { get; set; } = new List<Department>();

    public virtual ICollection<Department> DepartmentDeletedByNavigations { get; set; } = new List<Department>();

    public virtual ICollection<Department> DepartmentUpdatedByNavigations { get; set; } = new List<Department>();

    public virtual ICollection<Discount> DiscountCreatedByNavigations { get; set; } = new List<Discount>();

    public virtual ICollection<Discount> DiscountDeletedByNavigations { get; set; } = new List<Discount>();

    public virtual ICollection<Discount> DiscountUpdatedByNavigations { get; set; } = new List<Discount>();

    public virtual ICollection<EmergencyContact> EmergencyContactCreatedByNavigations { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<EmergencyContact> EmergencyContactDeletedByNavigations { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<EmergencyContact> EmergencyContactUpdatedByNavigations { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<EmployeeActivity> EmployeeActivityCreatedByNavigations { get; set; } = new List<EmployeeActivity>();

    public virtual ICollection<EmployeeActivity> EmployeeActivityDeletedByNavigations { get; set; } = new List<EmployeeActivity>();

    public virtual ICollection<EmployeeActivity> EmployeeActivityUpdatedByNavigations { get; set; } = new List<EmployeeActivity>();

    public virtual ICollection<Employee> EmployeeCreatedByNavigations { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeDeletedByNavigations { get; set; } = new List<Employee>();

    public virtual ICollection<EmployeeDepartment> EmployeeDepartmentCreatedByNavigations { get; set; } = new List<EmployeeDepartment>();

    public virtual ICollection<EmployeeDepartment> EmployeeDepartmentDeletedByNavigations { get; set; } = new List<EmployeeDepartment>();

    public virtual ICollection<EmployeeDepartment> EmployeeDepartmentUpdatedByNavigations { get; set; } = new List<EmployeeDepartment>();

    public virtual ICollection<EmployeeSchedule> EmployeeScheduleCreatedByNavigations { get; set; } = new List<EmployeeSchedule>();

    public virtual ICollection<EmployeeSchedule> EmployeeScheduleDeletedByNavigations { get; set; } = new List<EmployeeSchedule>();

    public virtual ICollection<EmployeeSchedule> EmployeeScheduleUpdatedByNavigations { get; set; } = new List<EmployeeSchedule>();

    public virtual ICollection<Employee> EmployeeUpdatedByNavigations { get; set; } = new List<Employee>();

    public virtual ICollection<Guest> GuestCreatedByNavigations { get; set; } = new List<Guest>();

    public virtual ICollection<Guest> GuestDeletedByNavigations { get; set; } = new List<Guest>();

    public virtual ICollection<GuestDocument> GuestDocumentCreatedByNavigations { get; set; } = new List<GuestDocument>();

    public virtual ICollection<GuestDocument> GuestDocumentDeletedByNavigations { get; set; } = new List<GuestDocument>();

    public virtual ICollection<GuestDocument> GuestDocumentUpdatedByNavigations { get; set; } = new List<GuestDocument>();

    public virtual ICollection<Guest> GuestUpdatedByNavigations { get; set; } = new List<Guest>();

    public virtual ICollection<Inventory> InventoryCreatedByNavigations { get; set; } = new List<Inventory>();

    public virtual ICollection<Inventory> InventoryDeletedByNavigations { get; set; } = new List<Inventory>();

    public virtual ICollection<Inventory> InventoryUpdatedByNavigations { get; set; } = new List<Inventory>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequestCreatedByNavigations { get; set; } = new List<MaintenanceRequest>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequestDeletedByNavigations { get; set; } = new List<MaintenanceRequest>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequestUpdatedByNavigations { get; set; } = new List<MaintenanceRequest>();

    public virtual ICollection<Payment> PaymentCreatedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentDeletedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentUpdatedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Purchase> PurchaseCreatedByNavigations { get; set; } = new List<Purchase>();

    public virtual ICollection<Purchase> PurchaseDeletedByNavigations { get; set; } = new List<Purchase>();

    public virtual ICollection<Purchase> PurchaseUpdatedByNavigations { get; set; } = new List<Purchase>();

    public virtual ICollection<Reservation> ReservationCreatedByNavigations { get; set; } = new List<Reservation>();

    public virtual ICollection<Reservation> ReservationDeletedByNavigations { get; set; } = new List<Reservation>();

    public virtual ICollection<Reservation> ReservationUpdatedByNavigations { get; set; } = new List<Reservation>();

    public virtual ICollection<Room> RoomCreatedByNavigations { get; set; } = new List<Room>();

    public virtual ICollection<Room> RoomDeletedByNavigations { get; set; } = new List<Room>();

    public virtual ICollection<RoomHistory> RoomHistories { get; set; } = new List<RoomHistory>();

    public virtual ICollection<RoomServiceOrder> RoomServiceOrderCreatedByNavigations { get; set; } = new List<RoomServiceOrder>();

    public virtual ICollection<RoomServiceOrder> RoomServiceOrderDeletedByNavigations { get; set; } = new List<RoomServiceOrder>();

    public virtual ICollection<RoomServiceOrder> RoomServiceOrderUpdatedByNavigations { get; set; } = new List<RoomServiceOrder>();

    public virtual ICollection<Room> RoomUpdatedByNavigations { get; set; } = new List<Room>();

    public virtual ICollection<Service> ServiceCreatedByNavigations { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceDeletedByNavigations { get; set; } = new List<Service>();

    public virtual ICollection<ServiceInventory> ServiceInventoryCreatedByNavigations { get; set; } = new List<ServiceInventory>();

    public virtual ICollection<ServiceInventory> ServiceInventoryDeletedByNavigations { get; set; } = new List<ServiceInventory>();

    public virtual ICollection<ServiceInventory> ServiceInventoryUpdatedByNavigations { get; set; } = new List<ServiceInventory>();

    public virtual ICollection<Service> ServiceUpdatedByNavigations { get; set; } = new List<Service>();

    public virtual ICollection<SpecialOffer> SpecialOfferCreatedByNavigations { get; set; } = new List<SpecialOffer>();

    public virtual ICollection<SpecialOffer> SpecialOfferDeletedByNavigations { get; set; } = new List<SpecialOffer>();

    public virtual ICollection<SpecialOffer> SpecialOfferUpdatedByNavigations { get; set; } = new List<SpecialOffer>();

    public virtual ICollection<SpecialRequest> SpecialRequestCreatedByNavigations { get; set; } = new List<SpecialRequest>();

    public virtual ICollection<SpecialRequest> SpecialRequestDeletedByNavigations { get; set; } = new List<SpecialRequest>();

    public virtual ICollection<SpecialRequest> SpecialRequestUpdatedByNavigations { get; set; } = new List<SpecialRequest>();

    public virtual ICollection<Supplier> SupplierCreatedByNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<Supplier> SupplierDeletedByNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<Supplier> SupplierUpdatedByNavigations { get; set; } = new List<Supplier>();
}
