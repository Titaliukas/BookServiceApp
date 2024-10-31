export interface ReservationDto{
    id: number | undefined;
    bookId: number;
    type: string;
    quickPickUp: boolean;
    days: number;
    price: number;
    createDate: string | undefined
}
