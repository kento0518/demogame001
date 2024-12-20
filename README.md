# demogame001

## 開発フロー

### ブランチ運用
- 作業を始める際は、必ず `master` ブランチから新しいブランチを切ってください。
- 作業が完了したら、`master` ブランチにマージし、最後に `master` にプッシュしてください。

### コミットメッセージのルール
- コミットメッセージは以下のフォーマットに従って記述してください：

```bash
git commit -m "prefix:module:具体的な内容"

```
prefix一覧
feat: 新機能の追加
例: "feat:gamebase:キャラクターが移動する機能を実装"
fix: バグ修正
例: "fix:ui:スタートボタンがクリックできない不具合を修正"
refactor: コードのリファクタリング（動作の変更なし）
例: "refactor:physics:キャラクターの速度計算を整理"
docs: ドキュメントの変更（READMEやコメントなど）
例: "docs:readme:開発フローを更新"
style: コードスタイルの修正（フォーマット変更やスペース整理、動作に影響しない変更）
例: "style:ui:コードのインデントを修正"
test: テスト関連の変更や新規追加
例: "test:physics:ジャンプ挙動のユニットテストを追加"
chore: その他の作業（ビルド設定、ライブラリ更新、ツール設定など）

