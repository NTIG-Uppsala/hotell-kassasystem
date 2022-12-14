
-- get all rooms that are not booked for a given date range (startDate, endDate)
SELECT r.floor, r.roomNumber, r.rate, b.dateFrom, b.dateTo, r2.type
FROM rooms r 
	LEFT JOIN roomsBooked r1 ON ( r1.roomID = r.roomID  )  
	LEFT JOIN bookings b ON ( b.bookingID = r1.bookingID  )  
	LEFT JOIN roomTypes r2 ON ( r2.roomTypesID = r.roomTypesID  )  
WHERE (r.roomID NOT IN (SELECT roomID FROM roomsBooked)) OR NOT (@checkIn <= b.dateTo AND @checkoutDate >= b.dateFrom);
