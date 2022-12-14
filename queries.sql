
-- get all rooms that are not booked for a given date range (startDate, endDate)
SELECT *
FROM rooms r 
	LEFT JOIN roomsBooked r1 ON ( r1.roomID = r.roomID  )  
	LEFT JOIN bookings b ON ( b.bookingID = r1.bookingID  )  
	LEFT JOIN roomTypes r2 ON ( r2.roomTypesID = r.roomTypesID  )  
WHERE (r.roomID NOT IN (SELECT roomID FROM roomsBooked)) OR NOT (b.dateFrom <= @startDate AND @endDate <= b.dateTo);