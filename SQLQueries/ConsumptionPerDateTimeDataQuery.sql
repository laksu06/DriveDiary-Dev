SELECT RefuelEvents.RefuelDateTime, RefuelEvents.RefuelAmount 
FROM Cars
	INNER JOIN RefuelEvents
	ON Cars.Id = RefuelEvents.CarId
	WHERE Cars.Id=1
	ORDER BY RefuelEvents.RefuelDateTime;