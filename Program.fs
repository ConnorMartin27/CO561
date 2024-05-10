open System
type Account(accountNumber: string, balance: float) =
    member this.AccountNumber = accountNumber
    member this.Balance = balance

    member this.Withdrawal(amount: float) =
        if amount <= this.Balance then
             new Account(accountNumber = this.AccountNumber, balance = this.Balance - amount) 
        else
            printfn "Not enough for withdrawel."
            this

    member this.Deposit(amount: float) =
         new Account(accountNumber = this.AccountNumber, balance = this.Balance + amount) 

    member this.Print() =
        printfn "Account Number: %s, Balance: %.2f" this.AccountNumber this.Balance

    member this.CheckAccount() =
        match balance with
        | b when b < 10.0 -> printfn("Balance is low")
        | b when b >= 10.0 && b <= 100.0 -> printfn("Balance is ok")
        | b when b > 100.0 -> printfn("Balance is high")



let test1 = new Account("0001", 0.0)
let test2 = new Account("0002", 51.0)
let test3 = new Account("0003", 5.0)
let test4 = new Account("0004", 101.0)
let test5 = new Account("0005", 99)
let test6 = new Account("0006", 11)

test1.CheckAccount()
test2.CheckAccount()
test3.CheckAccount()
test4.CheckAccount()
test5.CheckAccount()
test6.CheckAccount()

let accounts = [
    test1; 
    test2; 
    test3; 
    test4; 
    test5; 
    test6;
]

accounts
|> Seq.iter (fun account ->
    match account.Balance with
    | b when b >= 0 && b < 50 -> printf "%s" account.AccountNumber
    | _ -> printfn ""
)

accounts
|> Seq.iter (fun account ->
    match account.Balance with
    | b when b <= 50 -> printf "%s" account.AccountNumber
    | _ -> printfn ""
)

type Ticket = {seat:int; customer:string}

let mutable tickets = [for n in 1..10 -> {Ticket.seat = n; Ticket.customer = ""}]

let DisplayTickets() =
    printfn "tickets"
    tickets |> List.iter (fun ticket -> printfn "Seat: %d, Customer: %s" ticket.seat ticket.customer)


DisplayTickets()

let BookSeat customerName seatNumber =
        if seatNumber >= 1 && seatNumber <= 10 then
            let ticket = List.tryFind (fun t -> t.seat = seatNumber && t.customer = "") tickets
            match ticket with
            | Some(t) ->
                printfn "Booking seat %d for customer %s..." seatNumber customerName
                tickets <- List.map (fun t -> if t.seat = seatNumber then { t with customer = customerName } else t) tickets
                printfn "Seat %d booked successfully for customer %s" seatNumber customerName
            | None -> printfn "Seat %d is already booked or invalid" seatNumber
        else
            printfn "Invalid seat number: %d" seatNumber