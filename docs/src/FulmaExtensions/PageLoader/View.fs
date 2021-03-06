module FulmaExtensions.PageLoader.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Common
open Fulma.Extensions
open Fulma.Extra.FontAwesome
open Elmish.Browser
open Fable.Import.Browser


let basicInteractive (model:Model) (dispatch:Msg->unit) =
    div [ ]
        [ PageLoader.pageLoader [ yield PageLoader.Types.Color model.Color
                                  if model.IsLoading then
                                    yield PageLoader.isActive ]
            [ ]
          Content.content [ ]
            [ p [ ]
                [ str "Click on a button to display a loader for 3 sec" ] ]
          div [ ClassName "block" ]
            [
                Button.button [ Button.isBlack
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsBlack))] [ str "Show loader" ]
                Button.button [ Button.isDanger
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsDanger))] [ str "Show loader" ]
                Button.button [ Button.isDark
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsDark))] [ str "Show loader" ]
                Button.button [ Button.isInfo
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsInfo))] [ str "Show loader" ]
                Button.button [ Button.isLight
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsLight))] [ str "Show loader" ]
                Button.button [ Button.isPrimary
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsPrimary))] [ str "Show loader" ]
                Button.button [ Button.isSuccess
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsSuccess))] [ str "Show loader" ]
                Button.button [ Button.isWarning
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsWarning))] [ str "Show loader" ]
                Button.button [ Button.isWhite
                                Button.onClick (fun _ -> dispatch (IsLoadingMsg IsWhite))] [ str "Show loader" ] ] ]

let root model dispatch =
    Render.docPage [    Render.contentFromMarkdown model.Intro
                        Render.docSection
                            ""
                            (Viewer.View.root (basicInteractive model dispatch) model.Viewer (ViewerMsg >> dispatch))
                        Render.contentFromMarkdown
                            """
### Properties

State:

- `PageLoader.isActive`

Color:

- `PageLoader.isBlack`
- `PageLoader.isDark`
- `PageLoader.isLight`
- `PageLoader.isWhite`
- `PageLoader.isPrimary`
- `PageLoader.isInfo`
- `PageLoader.isSuccess`
- `PageLoader.isWarning`
- `PageLoader.isDanger`
                            """
                    ]
