SELECT RefuelEvents.RefuelMileage, RefuelEvents.RefuelAmount 
FROM Cars
	INNER JOIN RefuelEvents
	ON Cars.Id = RefuelEvents.CarId
	WHERE Cars.Id=1 AND RefuelEvents.RefuelMileage BETWEEN 143000 AND 144900
	ORDER BY RefuelEvents.RefuelMileage;