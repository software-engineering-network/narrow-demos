# [The most important TDD rule](https://enterprisecraftsmanship.com/posts/most-important-tdd-rule/)

> Unit tests should operate concepts that are one level of abstraction above the code these unit tests verify.

Long story short - we should not test the implementation of a set of functionality. We should test the end result.

Sometimes though, you still need a mock to test that a piece of functionality is correct.
In this example, the `EnrollmentService` assigns a `Student` to a `Class` and returns an `Enrollment` object.
This object is likely something that will be committed to storage.
The `Enrollment` object is created as part of the `Register()` method, and the service uses its `private` factory method to create it.

It is important that we test that the `EnrolledOn` property is set properly because the values we can test for are inconclusive.

* For example, `EnrolledOn` is not nullable. So we cannot simply check that it `is not null`. 
* Similarly, checking that `EnrolledOn` is not `DateTime.Min` doesn't seem appropriate either, since it's actually supposed to be a timestamp of the activity. 
* We also cannot assert `EnrolledOn` against `DateTime.Now` in the test, since that value will differ slightly from the one set as part of the `Register()` method.

So we create a mock for the `IDateTimeProvider` dependency so we can have a definitive `DateTime` to check for.
We aren't doing this because we care that the `Register()` method uses its dependency.
We're doing it because this is the correct test to make sure that the value is set.
Note that we do not have access to the `private` factory method, nor do we even know that it is called or exists.

It's splitting hairs as to whether or not you want to call this a unit and/or integration test.
It's technically an integration, but it's also just a simple, external (to the domain) dependency-free test of the `Register()` method.
