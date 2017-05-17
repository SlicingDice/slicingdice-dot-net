# Change Log

## [2.0.1]
### Added
- CLIENT: Rename Index() to Insert()
- CLIENT: Add missing API exceptions in client
- CLIENT: Add support to custom key
- CLIENT: Add endpoints keys level
- CLIENT: Add tests for data extraction
### Updated
- CLIENT: Rename SlicingDice API endpoints

### Updated
- Update `ExistsEntity()` to receive `table` as parameter
- Update API errors code

## [0.3] - 2016-09-29
### Added
- CLIENT: Create method isMasterLeveKey in SlicingDice class

## [0.2] - 2016-08-30
### Added
- CLIENT: Create TestSlicingDice class
- CLIENT: Create DataExtractionQueryValidator class
- CLIENT: Create ColumnValidator class
- CLIENT: Create QueryCountValidator class
- CLIENT: Create QueryTopValuesValidator class
- CLIENT: Create SavedQueryValidator class
- CLIENT: File queries.json
- CLIENT: Validators exceptions

### Changed
- CLIENT: URLResources.QueryCountEntity value
- CLIENT: URLResources.QueryCountEvent value
- CLIENT: All SlicingDice methods to accept validators

## [0.1] - 2016-08-29
### Added
- CLIENT: Create APIKey class
- CLIENT: Create all client Exceptions
- CLIENT: Create URLResources class
- CLIENT: Create Requester class
- CLIENT: Create HandlerResponse class
- CLIENT: Create SlicingDice class
- CLIENT: GetProject() to get all projects from SlicingDice
- CLIENT: GetColumns() to get all columns from SlicingDice
- CLIENT: GetSavedQuery() to get a query saved from SlicingDice
- CLIENT: CreateSavedQuery() to create a saved query in SlicingDice
- CLIENT: UpdateSavedQuery() to create a saved query in SlicingDice
- CLIENT: TopValues() to make a top values query in SlicingDice
- CLIENT: ExistsEntity() to make a exists entity query in SlicingDice
- CLIENT: CountEvent() to make a count event query in SlicingDice
- CLIENT: CountEntity() to make a count entity query in SlicingDice
- CLIENT: CountEntityTotal() get total count entity queries SlicingDice
- CLIENT: Index() to index a data in SlicingDice
- CLIENT: CreateColumn() to create column in SlicingDice
