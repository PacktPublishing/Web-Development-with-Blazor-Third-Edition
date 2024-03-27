declare global {
    interface Window {
        MarkdownToolbarElement: typeof MarkdownToolbarElement;
        MarkdownHeaderButtonElement: typeof MarkdownHeaderButtonElement;
        MarkdownBoldButtonElement: typeof MarkdownBoldButtonElement;
        MarkdownItalicButtonElement: typeof MarkdownItalicButtonElement;
        MarkdownQuoteButtonElement: typeof MarkdownQuoteButtonElement;
        MarkdownCodeButtonElement: typeof MarkdownCodeButtonElement;
        MarkdownLinkButtonElement: typeof MarkdownLinkButtonElement;
        MarkdownImageButtonElement: typeof MarkdownImageButtonElement;
        MarkdownUnorderedListButtonElement: typeof MarkdownUnorderedListButtonElement;
        MarkdownOrderedListButtonElement: typeof MarkdownOrderedListButtonElement;
        MarkdownTaskListButtonElement: typeof MarkdownTaskListButtonElement;
        MarkdownMentionButtonElement: typeof MarkdownMentionButtonElement;
        MarkdownRefButtonElement: typeof MarkdownRefButtonElement;
        MarkdownStrikethroughButtonElement: typeof MarkdownStrikethroughButtonElement;
    }
    interface HTMLElementTagNameMap {
        'markdown-toolbar': MarkdownToolbarElement;
        'md-header': MarkdownHeaderButtonElement;
        'md-bold': MarkdownBoldButtonElement;
        'md-italic': MarkdownItalicButtonElement;
        'md-quote': MarkdownQuoteButtonElement;
        'md-code': MarkdownCodeButtonElement;
        'md-link': MarkdownLinkButtonElement;
        'md-image': MarkdownImageButtonElement;
        'md-unordered-list': MarkdownUnorderedListButtonElement;
        'md-ordered-list': MarkdownOrderedListButtonElement;
        'md-task-list': MarkdownTaskListButtonElement;
        'md-mention': MarkdownMentionButtonElement;
        'md-ref': MarkdownRefButtonElement;
        'md-strikethrough': MarkdownStrikethroughButtonElement;
    }
}
declare class MarkdownButtonElement extends HTMLElement {
    constructor();
    connectedCallback(): void;
    click(): void;
}
declare class MarkdownHeaderButtonElement extends MarkdownButtonElement {
    #private;
    connectedCallback(): void;
    static get observedAttributes(): string[];
    attributeChangedCallback(name: string, oldValue: string, newValue: string): void;
}
declare class MarkdownBoldButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownItalicButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownQuoteButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownCodeButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownLinkButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownImageButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownUnorderedListButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownOrderedListButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownTaskListButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownMentionButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownRefButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownStrikethroughButtonElement extends MarkdownButtonElement {
    connectedCallback(): void;
}
declare class MarkdownToolbarElement extends HTMLElement {
    static observedAttributes: string[];
    connectedCallback(): void;
    attributeChangedCallback(name: string, oldValue: string, newValue: string): void;
    disconnectedCallback(): void;
    get field(): HTMLTextAreaElement | null;
}
export default MarkdownToolbarElement;
