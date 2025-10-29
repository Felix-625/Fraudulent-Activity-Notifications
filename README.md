# Fraudulent-Activity-Notifications

This solution efficiently tracks expenditures using a frequency array to count occurrences of each spending value in a sliding window of size d. For each new expenditure, it calculates the median from the frequency counts without sorting by finding the middle values through cumulative frequency counting. If the current day's spending is at least twice the median, it increments the notification count while maintaining the sliding window by updating the frequency array.
